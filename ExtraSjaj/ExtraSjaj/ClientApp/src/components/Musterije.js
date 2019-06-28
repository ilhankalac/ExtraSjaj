import React, { Component } from 'react';
import { Button, Table } from 'reactstrap';
import axios from 'axios';
import { browserHistory } from 'react-router';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';
import DeleteIcon from '@material-ui/icons/Delete';
import Icon from '@material-ui/core/Icon';
import RacunList from './ListGroupCollapse';


export class Musterije extends Component {

    static displayName = Musterije.name;
    state = {
        musterijeNiz: [],
        racuniMusterije: [],
        loading: false,
        RacuniModal: false,
        DialogMusterija: {
            id: '',
            ime: '',
            prezime: ''
        },
        open: false
    }

    routeChangeToCreate() {

        browserHistory.push('/CreateMusterija');
    }

    routeChangeToEdit(Musterija) {

        browserHistory.push({ pathname: '/EditMusterija', state: { Edit: Musterija } });
    }

    handleClickOpen = (id, ime, prezime) => {
        this.setState({
            RacuniModal: true,
            DialogMusterija: {
                id, ime, prezime
            }
        })

        this.loadRacuni(id)


    }

    handleClose() {
        this.setState({
            RacuniModal: false,
            racuniMusterije: []
        })

    }




    handleClick() {
        this.setState({
            open: !this.state.open
        })
    }

    loadRacuni = (id) => {
        axios.get("api/Racuns/musterija/" + id).then((response) => {
            this.setState({
                racuniMusterije: response.data
            });
        });
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
        this.handleClickOpen()
    }

    createNewRacun(id) {
        let racun = {
            musterijaId: id
        }
        axios.post("api/Racuns", racun);

    }

    render() {
        //refreshing data from database on page redirections to this page
        this.componentWillMount();
        let i = 1;
        let tableData =
            this.state.musterijeNiz.map(item =>
                <tr key={item.id}>
                    <td> {i++} </td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.ime}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.prezime}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.brojTelefona}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.adresa}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.vrijemeKreiranjaMusterije}</td>
                    <td>
                        <Fab size="small" spacing={5} color="primary" aria-label="Edit" onClick={this.routeChangeToEdit.bind(this, item)}>
                            <Icon>edit_icon</Icon>
                        </Fab>
                        <Fab className="ml-3" size="small" aria-label="Delete" color="secondary" onClick={this.deleteMusterija.bind(this, item.id)}>
                            <DeleteIcon />
                        </Fab>
                        <Button size="sm" className="ml-3" onClick={this.createNewRacun.bind(this, item.id)} color="success">
                            Novi racun
                            </Button>
                    </td>
                </tr>
            );

        return (
            <div>
                <div>
                    <Dialog size="lg" open={this.state.RacuniModal} onClose={this.handleClose.bind(this)} aria-labelledby="form-dialog-title">
                        <DialogTitle id="form-dialog-title">     Ovo su svi racuni {this.state.DialogMusterija.ime} {this.state.DialogMusterija.prezime}</DialogTitle>
                        <DialogActions>

                        </DialogActions>
                        <DialogContent>
                            <DialogContentText>

                            </DialogContentText>

                            {this.state.racuniMusterije.map((item) =>
                                <RacunList key={item.id} racun={item} />
                            )}

                        </DialogContent>

                    </Dialog>
                </div>

                <center> <h1>Lista mušterija</h1> </center>
                <Fab color="primary" aria-label="Add" onClick={this.routeChangeToCreate} >
                    <AddIcon />
                </Fab>

                <Table dark className='table table-striped'>
                    <thead>
                        <tr>
                            <th>#</th>
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