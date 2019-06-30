import React from 'react';
import { ListGroupItem, Collapse, Button, Input, Row, Col } from 'reactstrap';
import ListSubheader from '@material-ui/core/ListSubheader';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import CheckCircle from '@material-ui/icons/CheckCircle';
import Block from '@material-ui/icons/Block';
import axios from 'axios';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import TabUnselected from '@material-ui/icons/TabUnselected';
import Icon from '@material-ui/core/Icon';


class RacunList extends React.Component {
    state = {
        collapse: false,
        Racun: this.props.racun,
        tepisi: [],
        strelica: false,
        TepihDialog: false,
        Hidden: false,
        newTepih: {
            sirina: '',
            duzina: '',
            racunId: ''
        }
    };

    constructor(props) {
        super(props);

        this.toggle = this.toggle.bind(this);
        this.state = {
            collapse: false,
            strelica: false,
            Hidden: false,
            Racun: this.props.racun,
            tepisi: [],
            TepihDialog: false,
            newTepih: {
                sirina: '',
                duzina: '',
                racunId: ''
            },

            Datum: (this.props.racun.vrijemeKreiranjaRacuna.toString().slice(5, 7)) + "." +
                (this.props.racun.vrijemeKreiranjaRacuna.toString().slice(8, 10)) + "." +
                (this.props.racun.vrijemeKreiranjaRacuna.toString().slice(0, 4)) + " u " +
                (this.props.racun.vrijemeKreiranjaRacuna.toString().slice(11, 16))
        };

    }
    dismiss = () => {
        this.setState({
            Hidden: true
        })
    }
    deleteTepih = (item) => {
        axios.delete("api/Tepihs/" + item.id);

        this.setState({
            tepisi: this.state.tepisi.filter(olditem => olditem !== item),
            Racun: this.props.racun
        });

    }

    deleteRacun = () => {
        axios.delete("api/Racuns/" + this.state.Racun.id);
        this.dismiss()


    }

    componentWillMount() {

        axios.get("api/Tepihs/Racun/" + this.props.racun.id).then((response) => {
            this.setState({
                tepisi: response.data,
                Racun: this.props.racun
            });
        });

    }

    toggle = () => {
        this.setState({ collapse: !this.state.collapse });
        axios.get("api/Tepihs/Racun/" + this.props.racun.id).then((response) => {
            this.setState({
                tepisi: response.data
            });
        });
    }

    handleClose = () => {
        this.setState({
            TepihDialog: false,
            newTepih: {
                sirina: '',
                duzina: '',
                racunId: ''
            }
        })

    }
    handleNewTepih = () => {


        this.state.newTepih.racunId = this.state.Racun.id
        axios.post("api/Tepihs", this.state.newTepih).then((response) => {
            console.log(response)
            this.setState({
                strelica: false,
                TepihDialog: false,
                newTepih:
                {
                    duzina: '',
                    sirina: '',
                    racunId: ''
                },
                tepisi: [...this.state.tepisi, response.data],
                Racun: response.data.racun
            })
        }).catch(error => {
            console.log(error.response)
        });
    }



    toggleTepihDialogue = () => {
        this.setState({
            TepihDialog: true,
            strelica: true
        })

    }
    render() {
        let i = 1;
        let deleteRacun

        if (this.state.Racun.vrijednost === 0) {
            console.log(this.state.Racun.vrijednost)
            deleteRacun = <Button onClick={this.deleteRacun.bind(this)}> Delete racun </Button>
        }

        if (this.state.Racun && !this.state.Hidden)
            return (

                <div >
                    <div >
                        <Dialog size="lg" open={this.state.TepihDialog} onClose={this.handleClose.bind(this)} aria-labelledby="form-dialog-title">
                            <DialogTitle id="form-dialog-title">   Dodavanje novog tepiha   </DialogTitle>

                            <DialogContent>
                                <DialogContentText>
                                    <Row>
                                        <Col sm={{ size: 3, offset: 1 }}>

                                            <Input type="number" className="mr-2" id="duzina" placeholder="dužina"
                                                onChange={(e) => {
                                                    let { newTepih } = this.state;
                                                    newTepih.duzina = e.target.value;
                                                    this.setState({ newTepih });
                                                }}
                                            />
                                        </Col>

                                        <Col disabled sm={{ size: 2, offset: 1 }}>
                                            <Input disabled className="mr-2" defaultValue="    X" />
                                        </Col>
                                        <Col sm={{ size: 3, offset: 1 }}>

                                            <Input type="number" className="mr-2" type="sirina" id="sirina" placeholder="širina"
                                                onChange={(e) => {
                                                    let { newTepih } = this.state;
                                                    newTepih.sirina = e.target.value;
                                                    this.setState({ newTepih });
                                                }} />
                                        </Col>
                                    </Row>
                                </DialogContentText>


                            </DialogContent>
                            <DialogActions>
                                <Button onClick={this.handleNewTepih.bind(this)} > Potvrdi </Button>
                            </DialogActions>
                        </Dialog>
                    </div>

                    <ListGroupItem>
                        <div>

                            <List
                                component="nav"
                                aria-labelledby="nested-list-subheader"
                                subheader={
                                    <ListSubheader component="div" id="nested-list-subheader">

                                    </ListSubheader>
                                }
                            >
                                <ListItem button onClick={this.toggle.bind(this)}>
                                    <ListItemIcon>
                                        {this.state.Racun.placen ? <CheckCircle color="primary" /> : <Block color="secondary" />}
                                    </ListItemIcon>


                                    <ListItemText primary={this.state.Racun.vrijednost + "€"} className="mr-3" />
                                    <ListItemText className="ml-3" primary={this.state.Datum} color="secondary" />
                                    <Icon onClick={this.toggleTepihDialogue.bind(this)} className="m-2" color="primary" fontSize="large" >
                                        add_circle
                                    </Icon>
                                    {this.state.strelica ? <ExpandLess /> : <ExpandMore />}
                                    {deleteRacun}
                                </ListItem>
                                <Collapse isOpen={this.state.collapse}>
                                    <List component="div" disablePadding>
                                        {this.state.tepisi.map((item) =>
                                            <ListItem button >
                                                <ListItemIcon>
                                                    <TabUnselected />
                                                </ListItemIcon>
                                                <ListItemText primary={(i++) + "-> " + item.sirina + " x " + item.duzina + " = " + (item.sirina * item.duzina) + "m²"} />
                                                {
                                                    this.state.Racun.placen ? <p /> : <Button onClick={this.deleteTepih.bind(this, item)}>Delete </Button>


                                                }

                                            </ListItem>
                                        )}
                                    </List>
                                </Collapse>
                            </List>
                        </div>
                    </ListGroupItem>
                </div>
            )
        else
            return (

                <p></p>)
    }
}

export default RacunList