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
import PlaylistAdd from '@material-ui/icons/PlaylistAdd';
import Grid from '@material-ui/core/Grid';
import Input from '@material-ui/core/Input';
import Search from '@material-ui/icons/Search';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import { RoleAwareComponent } from 'react-router-role-authorization';
import { NotFound } from './NotFound';
import Cookies from 'js-cookie';


const theme = createMuiTheme({
    palette: {
        inherit: '#37474f',
        secondary: {
            main: '#c62828'
        },

    }
});

export class Korisnici extends RoleAwareComponent {
    constructor(props) {
        super(props);

        this.allowedRoles = '1';
        this.userRoles = Cookies.get('user');


    }
    rolesMatched = () => {
        if (this.allowedRoles === this.userRoles)
            return true
        else
            return false

    }

    state = {
        musterijeNiz: [],
        racuniMusterije: [],
        loading: false,
        search: '',
        RacuniModal: false,
        DialogMusterija: {
            id: '',
            ime: '',
            prezime: ''
        },
        open: false
    }
    notFoundPush = () => {

        browserHistory.push({ pathname: '/' })
           
    }

    routeChangeToEdit = (Korisnik) => {

        browserHistory.push({ pathname: '/EditKorisnik', state: { Edit: Korisnik } });
    }

    componentWillMount() {
        axios.get("api/Users").then((response) => {
            this.setState({
                musterijeNiz: response.data
            });
        });
    }

    deleteMusterija = (id) => {

        axios.delete("api/Users/" + id);

    }



    render() {
        //refreshing data from database on page redirections to this page
        this.componentWillMount();
        let i = 1;

        let filteredData = this.state.musterijeNiz.filter((item) => {
            let result = item.ime.toLowerCase().indexOf(this.state.search.toLowerCase()) !== -1 || item.prezime.toLowerCase().indexOf(this.state.search.toLowerCase()) !== -1
                || item.jmbg.toLowerCase().indexOf(this.state.search.toLowerCase()) !== -1 || item.brojTelefona.toLowerCase().indexOf(this.state.search.toLowerCase()) !== -1
                || item.username.toLowerCase().indexOf(this.state.search) !== -1
            return result
        })


        let tableData =
            filteredData.map(item =>
                <tr key={item.id}>
                    <td> {i++} </td>
                    <td >{item.ime}</td>
                    <td >{item.prezime}</td>
                    <td >{item.username}</td>
                    <td >{item.jmbg}</td>
                    <td >{item.brojTelefona}</td>
                    <td >{item.roleId === 1 ? 'Admin' : 'Radnik'}</td>


                    <td>
                        <MuiThemeProvider theme={theme}>
                            <Fab size="small" color="primary" aria-label="Edit" onClick={this.routeChangeToEdit.bind(this, item)}>
                                <Icon>edit_icon</Icon>
                            </Fab>
                            <Fab className="ml-3" size="small" aria-label="Delete" color="secondary" onClick={this.deleteMusterija.bind(this, item.id)}>
                                <DeleteIcon />
                            </Fab>


                        </MuiThemeProvider>
                    </td>
                </tr>
            );


        let contents = (
            <div>
                <Grid
                    justify="space-between"
                    container

                >
                    <Grid item>
                      
                        <h1 className="mb-2" size="small" color="primary" aria-label="Add" >
                            Korisnici
                        </h1>
                            
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
                            <th>Korisničko ime</th>
                            <th>JMBG</th>
                            <th>Broj Telefona</th>
                            <th>Rola </th>
                        </tr>
                    </thead>
                    <tbody>
                        {tableData}
                    </tbody>
                </Table>
            </div>
        )

        return (
            this.rolesMatched() ? contents : <NotFound/>
        );
    }
}