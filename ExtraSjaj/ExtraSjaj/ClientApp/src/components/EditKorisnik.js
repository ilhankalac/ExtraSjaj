import React, { Component } from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import axios from 'axios';
import { browserHistory } from 'react-router';
import Radio from '@material-ui/core/Radio';
import RadioGroup from '@material-ui/core/RadioGroup';
import FormControl from '@material-ui/core/FormControl';
import FormLabel from '@material-ui/core/FormLabel';
import { RoleAwareComponent } from 'react-router-role-authorization';
import Cookies from 'js-cookie';


export class EditKorisnik extends RoleAwareComponent {


    constructor(props) {
        super(props);

        this.allowedRoles = '1';
        this.userRoles = Cookies.get('user');


    }


    state = {

        radio: '1',
        noviKorisnik: {

            id: this.props.location.state.Edit.id,
            ime: this.props.location.state.Edit.ime,
            prezime: this.props.location.state.Edit.prezime,
            username: this.props.location.state.Edit.username,
            password: this.props.location.state.Edit.password,
            jmbg: this.props.location.state.Edit.jmbg,
            brojTelefona: this.props.location.state.Edit.brojTelefona,
            roleId: this.props.location.state.Edit.roleId
        }
    }

    rolesMatched = () => {
        if (this.allowedRoles === this.userRoles)
            return true
        else
            return false

    }

    editMusterija() {

        axios.put("api/Users/" + this.state.noviKorisnik.id, this.state.noviKorisnik);
        browserHistory.push('/Korisnici');

    }

    rolesMatched = () => {
        if (this.allowedRoles === this.userRoles)
            return true
        else
            return false

    }
    handleChange = (event) => {

        //  var noviKorisnik = { ...this.state.noviKorisnik }
        //    noviKorisnik.rolaId = event.target.value;
        this.setState({
            noviKorisnik: { ...this.state.noviKorisnik, roleId: event.target.value },
            radio: event.target.value
        });



    }
    render() {

        let contents = (

            <Container component="main" maxWidth="xs">
                <CssBaseline />
                <div >
                    <Avatar >
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography className="mb-3 mt-2" component="h1" variant="h5">
                        Kreiranje novog naloga
        </Typography>
                    <form noValidate>
                        <Grid container spacing={2}>
                            <Grid item xs={12} sm={6}>
                                <TextField
                                    autoComplete="fname"
                                    name="firstName"
                                    variant="outlined"
                                    required
                                    fullWidth
                                    id="ime"
                                    label="Ime"
                                    autoFocus
                                    placeholder="Ime"
                                    value={this.state.noviKorisnik.ime}
                                    onChange={(e) => {
                                        let { noviKorisnik } = this.state;
                                        noviKorisnik.ime = e.target.value;
                                        this.setState({ noviKorisnik });
                                    }}
                                />
                            </Grid>
                            <Grid item xs={12} sm={6}>
                                <TextField
                                    variant="outlined"
                                    required
                                    fullWidth
                                    id="prezime"
                                    label="Prezime"
                                    name="lastName"
                                    autoComplete="lname"
                                    placeholder="prezime"
                                    value={this.state.noviKorisnik.prezime}
                                    onChange={(e) => {
                                        let { noviKorisnik } = this.state;
                                        noviKorisnik.prezime = e.target.value;
                                        this.setState({ noviKorisnik });
                                    }}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField
                                    variant="outlined"
                                    required
                                    fullWidth
                                    id="username"
                                    label="Korisničko ime"
                                    name="email"
                                    autoComplete="email"
                                    placeholder="korisničko ime"
                                    value={this.state.noviKorisnik.username}
                                    onChange={(e) => {
                                        let { noviKorisnik } = this.state;
                                        noviKorisnik.username = e.target.value;
                                        this.setState({ noviKorisnik });
                                    }}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField
                                    variant="outlined"
                                    required
                                    fullWidth
                                    id="username"
                                    label="Broj telefona"
                                    name="email"
                                    autoComplete="telephone"
                                    placeholder="broj telefona"
                                    value={this.state.noviKorisnik.brojTelefona}
                                    onChange={(e) => {
                                        let { noviKorisnik } = this.state;
                                        noviKorisnik.brojTelefona = e.target.value;
                                        this.setState({ noviKorisnik });
                                    }}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField
                                    variant="outlined"
                                    required
                                    fullWidth
                                    id="username"
                                    label="JMBG"
                                    name="JMBG"
                                    autoComplete="JMBG"
                                    placeholder="JMBG"
                                    value={this.state.noviKorisnik.jmbg}
                                    onChange={(e) => {
                                        let { noviKorisnik } = this.state;
                                        noviKorisnik.jmbg = e.target.value;
                                        this.setState({ noviKorisnik });
                                    }}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField
                                    variant="outlined"
                                    required
                                    fullWidth
                                    name="password"
                                    label="Lozinka"
                                    type="password"
                                    id="password"
                                    autoComplete="current-password"
                                    placeholder="lozinka"
                                    value={this.state.noviKorisnik.password}
                                    onChange={(e) => {
                                        let { noviKorisnik } = this.state;
                                        noviKorisnik.password = e.target.value;
                                        this.setState({ noviKorisnik });
                                    }}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <FormControl component="fieldset">
                                    <FormLabel className="ml-2" component="legend">Rola</FormLabel>
                                    <RadioGroup aria-label="position" name="position" value={this.state.radio} onChange={this.handleChange.bind(this)}
                                        row>

                                        <FormControlLabel
                                            value="1"
                                            control={<Radio color="primary" />}
                                            label="Aministrator"
                                            labelPlacement="start"
                                            className="mr-5"
                                        />

                                        <FormControlLabel
                                            value="2"
                                            control={<Radio color="primary" />}
                                            label="Radnik"
                                            className="ml-3"
                                            labelPlacement="end"
                                        />
                                    </RadioGroup>
                                </FormControl>
                            </Grid>
                        </Grid>
                        <Button

                            fullWidth
                            variant="contained"
                            color="primary"
                            onClick={this.editMusterija.bind(this)}

                        >
                            Kreiraj
          </Button>


                    </form>
                </div>
                <Box mt={5}>

                </Box>
            </Container>

        )

        return this.rolesMatched() ? contents : null;



    }

}

export default EditKorisnik