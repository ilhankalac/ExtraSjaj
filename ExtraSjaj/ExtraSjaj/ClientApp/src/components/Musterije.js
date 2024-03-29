﻿import React, { Component } from 'react';
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
import PlaylistAdd from '@material-ui/icons/PlaylistAdd';
import Grid from '@material-ui/core/Grid';
import Input from '@material-ui/core/Input';
import Search from '@material-ui/icons/Search';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import Popper from '@material-ui/core/Popper';
import { RoleAwareComponent } from 'react-router-role-authorization';
import Cookies from 'js-cookie';
import { NotFound } from './NotFound';

const theme = createMuiTheme({
    palette: {
        inherit: '#37474f',
        secondary: {
            main: '#c62828'
        },

    }
});

export class Musterije extends RoleAwareComponent {
    constructor(props) {
        super(props);

        this.allowedRoles = '1';
        this.userRoles = Cookies.get('user');


    }
    rolesMatched = () => {
        if (this.allowedRoles === this.userRoles || '2' === this.userRoles )
            return true
        else
            return false

    }
    static displayName = Musterije.name;
    state = {
        musterijeNiz: [],
        racuniMusterije: [],
        loading: false,
        search: '',
        RacuniModal: false,
        RacunCreated: false,
        DialogMusterija: {
            id: '',
            ime: '',
            prezime: ''
        },
        open: false
    }

    routeChangeToCreate = () => {

        browserHistory.push('/CreateMusterija');
    }

    routeChangeToEdit = (Musterija) => {

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

    handleClose = () => {
        this.setState({
            RacuniModal: false,
            racuniMusterije: []
        })

    }

    closeRacunCreated = () => {
        this.setState({
            RacunCreated: false,
           
        })

    }

    handleClick = () => {
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

    deleteMusterija = (id) => {

        axios.delete("api/Musterijas/" + id);

    }

    createNewRacun = (id) => {
        let racun = {
            musterijaId: id
        }
        this.state.RacunCreated = true;
        axios.post("api/Racuns", racun);

    }

    render() {
        //refreshing data from database on page redirections to this page
        this.componentWillMount();
        let i = 1;

        let filteredData = this.state.musterijeNiz.filter((item) => {
            let result = item.ime.toLowerCase().indexOf(this.state.search.toLowerCase()) !== -1 || item.prezime.toLowerCase().indexOf(this.state.search.toLowerCase()) !== -1
                || item.adresa.toLowerCase().indexOf(this.state.search.toLowerCase()) !== -1 || item.brojTelefona.toLowerCase().indexOf(this.state.search.toLowerCase()) !== -1 || item.vrijemeKreiranjaMusterije.toLowerCase().indexOf(this.state.search) !== -1
            return result
        })


        let tableData =
            filteredData.map(item =>
                <tr key={item.id}>
                    <td> {i++} </td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.ime}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.prezime}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.brojTelefona}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>{item.adresa}</td>
                    <td onClick={this.handleClickOpen.bind(this, item.id, item.ime, item.prezime)}>
                        {
                            (item.vrijemeKreiranjaMusterije.toString().slice(5, 7)) + "." +
                            (item.vrijemeKreiranjaMusterije.toString().slice(8, 10)) + "." +
                            (item.vrijemeKreiranjaMusterije.toString().slice(0, 4)) + " u " +
                            (item.vrijemeKreiranjaMusterije.toString().slice(11, 16))
                        }
                    </td>
                    <td>
                        <MuiThemeProvider theme={theme}>
                            <Fab size="small" color="primary" aria-label="Edit" onClick={this.routeChangeToEdit.bind(this, item)}>
                                <Icon>edit_icon</Icon>
                            </Fab>
                            <Fab className="ml-3" size="small" aria-label="Delete" color="secondary" onClick={this.deleteMusterija.bind(this, item.id)}>
                                <DeleteIcon />
                            </Fab>
                            <Fab className="ml-3" size="small" color="inherit" aria-label="Add" onClick={this.createNewRacun.bind(this, item.id)} >
                                <PlaylistAdd size="sm" color="inherit" />
                            </Fab>
                            <Dialog open={this.state.RacunCreated} onClose={this.closeRacunCreated.bind(this)}>      <DialogTitle id="alert-dialog-title">{"Uspešno dodat račun"}</DialogTitle>
                                <DialogContent>
                                    <DialogContentText id="alert-dialog-description">
                                        :)
          </DialogContentText>
                                </DialogContent></Dialog>
                        </MuiThemeProvider>
                    </td>
                </tr>
            );
        let contents=
         (
            <div>
                <div>
                    <Dialog size="lg" open={this.state.RacuniModal} onClose={this.handleClose.bind(this)} aria-labelledby="form-dialog-title">
                        <DialogTitle id="form-dialog-title">     {this.state.DialogMusterija.ime} {this.state.DialogMusterija.prezime} računi</DialogTitle>
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

                <Grid
                    justify="space-between"
                    container

                >
                    <Grid item>
                        <Fab className="mb-2" size="small" color="primary" aria-label="Add" onClick={this.routeChangeToCreate} >
                            <AddIcon />
                        </Fab>
                    </Grid>

                    <Grid item>
                        <div>
                            <Search />
                            <Input className="mr-2" type="search" id="search" placeholder="Pretraga"
                                onChange={(e) => {
                                    let { search } = this.state;
                                    search = e.target.value;
                                    this.setState({ search });
                                }} />
                        </div>
                    </Grid>
                </Grid>
                <Table className='table table-striped'>
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
        return (
            
            this.rolesMatched() ? contents : <NotFound />
            )
    }
}