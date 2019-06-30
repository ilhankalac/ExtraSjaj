import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import axios from 'axios';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import { browserHistory } from 'react-router';

import Cookies from 'js-cookie';

const theme = createMuiTheme({
    palette: {
        secondary: {
            main: '#7e57c2'
        }
    },
});

export class Login extends Component {

    state = {
        radio: '1',
        loginData: {


            username: '',
            password: '',

        }

    }

    loginNewKorisnik = () => {
        axios.post("api/Users/Login", this.state.loginData).then((response) => {
            console.log(JSON.stringify(response))
            var pom = response.data.rolaId
            console.log(pom)
            Cookies.set('user', pom);
            browserHistory.push('/Musterije');
        }).catch(error => {
            console.log(error.message);

        })


    }




    render() {
        return (
            <Container component="main" maxWidth="xs">
                <CssBaseline />
                <div >
                    <MuiThemeProvider theme={theme}>
                        <center>
                            <LockOutlinedIcon color="secondary" />

                            <Typography component="h1" variant="h5">
                                Prijavljivanje
                     </Typography> </center>
                    </MuiThemeProvider>
                    <form noValidate>
                        <TextField
                            variant="outlined"
                            margin="normal"
                            required
                            fullWidth
                            id="email"
                            label="Korisnicko ime"
                            name="email"
                            autoComplete="email"
                            autoFocus
                            placeholder="Korisnicko ime"
                            value={this.state.loginData.username}
                            onChange={(e) => {
                                let { loginData } = this.state;
                                loginData.username = e.target.value;
                                this.setState({ loginData });
                            }}
                        />
                        <TextField
                            variant="outlined"
                            margin="normal"
                            required
                            fullWidth
                            name="password"
                            label="Lozinka"
                            type="password"
                            id="password"
                            autoComplete="current-password"
                            placeholder="Lozinka"
                            value={this.state.loginData.password}
                            onChange={(e) => {
                                let { loginData } = this.state;
                                loginData.password = e.target.value;
                                this.setState({ loginData });
                            }}
                        />

                        <Button

                            fullWidth
                            variant="contained"
                            color="primary"
                            onClick={this.loginNewKorisnik.bind(this)}
                        >
                            Uloguj se
          </Button>

                    </form>
                </div>

            </Container>
        );
    }


}


export default Login