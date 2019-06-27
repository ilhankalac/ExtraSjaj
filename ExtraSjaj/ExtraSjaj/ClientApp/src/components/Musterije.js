import React, { Component } from 'react';
import { Button, Table } from 'reactstrap';
import axios from 'axios';
import { browserHistory } from 'react-router';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import { makeStyles } from '@material-ui/core/styles';
import ListSubheader from '@material-ui/core/ListSubheader';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Collapse from '@material-ui/core/Collapse';
import InboxIcon from '@material-ui/icons/MoveToInbox';
import DraftsIcon from '@material-ui/icons/Drafts';
import SendIcon from '@material-ui/icons/Send';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import StarBorder from '@material-ui/icons/StarBorder';







export class Musterije extends Component {

    static displayName = Musterije.name;


    routeChangeToCreate() {

        browserHistory.push('/CreateMusterija');
    }

    routeChangeToEdit(Musterija) {

        browserHistory.push({ pathname: '/EditMusterija', state: { Edit: Musterija } });
    }

    handleClickOpen(id, ime, prezime) {
        this.setState({
            RacuniModal: true,
            DialogMusterija: {
                id, ime, prezime
            }
        })
    }

    handleClose() {
        this.setState({
            RacuniModal: false
        })
    }


    state = {
        musterijeNiz: [],
        loading: false,
        RacuniModal: false,
        DialogMusterija: {
            id: '',
            ime: '',
            prezime: ''
        },
        open: false
    }

    handleClick() {
        this.setState({
            open: !this.state.open
        })
    }



    componentWillMount() {
        axios.get("api/Musterijas").then((response) => {
            this.setState({
                musterijeNiz: response.data
            });
        });
    }

    deleteMusterija(id) {

        axios.delete("api/Musterijas/" + id);

    }

    render() {
        //refreshing data from database on page redirections to this page
        this.componentWillMount();

        let tableData =
            this.state.musterijeNiz.map(item =>
                <tr key={item.id}>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.ime}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.prezime}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.brojTelefona}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.adresa}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.vrijemeKreiranjaMusterije}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>
                        <Button color="success" size="sm" className="mr-2" onClick={this.routeChangeToEdit.bind(this, item)}>Edit </Button>
                        <Button color="danger" size="sm" className="mr-2" onClick={this.deleteMusterija.bind(this, item.id)}> Obriši </Button>
                    </td>
                </tr>
            );

        return (
            <div>

                <div>
                    <Dialog open={this.state.RacuniModal} onClose={this.handleClose.bind(this)} aria-labelledby="form-dialog-title">
                        <DialogTitle id="form-dialog-title">     Ovo su svi racuni {this.state.DialogMusterija.ime} {this.state.DialogMusterija.prezime}</DialogTitle>
                        <DialogContent>
                            <DialogContentText>

                            </DialogContentText>
                            <List
                                component="nav"
                                aria-labelledby="nested-list-subheader"
                                subheader={
                                    <ListSubheader component="div" id="nested-list-subheader">
                                        Nested List Items
        </ListSubheader>
                                }

                            >
                                <ListItem button onClick={this.handleClick.bind(this)}>
                                    <ListItemIcon>
                                        <InboxIcon />
                                    </ListItemIcon>
                                    <ListItemText primary="Inbox" />
                                    {this.state.open ? <ExpandLess /> : <ExpandMore />}
                                </ListItem>
                                <Collapse in={this.state.open} timeout="auto" unmountOnExit>
                                    <List component="div" disablePadding>
                                        <ListItem button >
                                            <ListItemIcon>
                                                <StarBorder />
                                            </ListItemIcon>
                                            <ListItemText primary="Starred" />
                                        </ListItem>
                                    </List>
                                </Collapse>
                            </List>
                        </DialogContent>
                        <DialogActions>
                            <Button onClick={this.handleClose.bind(this)} color="primary">
                                Pregled racuna
          </Button>

                        </DialogActions>
                    </Dialog>
                </div>

                <center> <h1>Lista mušterija</h1> </center>
                <Button color="success" className="mr-3" onClick={this.routeChangeToCreate}> Kreiraj mušteriju </Button>
                <Table dark bordered className='table table-striped'>
                    <thead>
                        <tr>
                            <th>Ime</th>
                            <th>Prezime</th>
                            <th>Broj telefona</th>
                            <th>Adresa</th>
                            <th>Vrijeme kreiranja mušterije</th>
                            <th>Akcije </th>
                        </tr>
                    </thead>
                    <tbody>
                        {tableData}
                    </tbody>
                </Table>
            </div>
        );
    }
}