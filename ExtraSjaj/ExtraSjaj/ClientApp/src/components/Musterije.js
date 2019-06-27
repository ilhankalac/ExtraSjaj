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
        }
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
        let i = 1;
        let tableData =
            this.state.musterijeNiz.map(item =>
                <tr key={item.id} onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>
                    <td>{i++}</td>
                    <td>{item.ime}</td>
                    <td>{item.prezime}</td>
                    <td>{item.brojTelefona}</td>
                    <td>{item.adresa}</td>
                    <td>{item.vrijemeKreiranjaMusterije}</td>
                    <td>
                        <Button color="success" size="sm" className="mr-2" onClick={this.routeChangeToEdit.bind(this, item)}>Edit </Button>
                        <Button color="danger" size="sm" className="mr-2" onClick={this.deleteMusterija.bind(this, item.id)}> Obriši </Button>
                    </td>
                </tr>
            );

        return (
            <div>
                <div>
                    <Dialog open={this.state.RacuniModal} onClose={this.handleClose.bind(this)} aria-labelledby="form-dialog-title">
                        <DialogTitle id="form-dialog-title"> Ovo su svi racuni {this.state.DialogMusterija.ime} {this.state.DialogMusterija.prezime}</DialogTitle>
                        <DialogContent>
                            <DialogContentText>
                               
                            </DialogContentText>
                            <TextField
                                autoFocus
                                margin="dense"
                                id="name"
                                label="Email Address"
                                type="email"
                                fullWidth
                            />
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