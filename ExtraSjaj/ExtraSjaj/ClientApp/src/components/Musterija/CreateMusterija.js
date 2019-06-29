import React, { Component } from 'react';
import { Button, Input, Label, Row, Col } from 'reactstrap';
import axios from 'axios';
import { browserHistory } from 'react-router';

export class CreateMusterija extends Component {

    state = {

        novaMusterija: {
            ime: '',
            prezime: '',
            brojTelefona: '',
            adresa: ''
        }

    }

    createNewMusterija() {

        axios.post("api/Musterijas", this.state.novaMusterija);
        browserHistory.push('/Musterije');

    }

    render() {
        return (
            <div>
                <h1>Lista mušterija</h1>
                <Row>
                    <Col sm={{ size: 6, offset: 1 }}>
                        <Label className="mr-2" for="ime"> Ime </Label>
                        <Input className="mr-2" id="ime" placeholder="Ime"
                            onChange={(e) => {
                                let { novaMusterija } = this.state;
                                novaMusterija.ime = e.target.value;
                                this.setState({ novaMusterija });
                            }}
                        />
                    </Col>
                    <Col sm={{ size: 6, offset: 1 }}>
                        <Label className="mr-2" for="prezime"> Prezime </Label>
                        <Input className="mr-2" type="text" id="prezime" placeholder="Prezime"
                            onChange={(e) => {
                                let { novaMusterija } = this.state;
                                novaMusterija.prezime = e.target.value;
                                this.setState({ novaMusterija });
                            }}/>
                    </Col>
                    <Col sm={{ size: 6, offset: 1 }}>
                        <Label className="mr-2" for="prezime"> Broj telefona </Label>
                        <Input className="mr-2" type="text" id="brojTelefona" placeholder="Broj telefona"
                            onChange={(e) => {
                                let { novaMusterija } = this.state;
                                novaMusterija.brojTelefona = e.target.value;
                                this.setState({ novaMusterija });
                            }}/>
                    </Col>
                    <Col sm={{ size: 6, offset: 1 }}>
                        <Label className="mr-2" for="prezime"> Adresa </Label>
                        <Input className="mr-2" type="text" id="adresa" placeholder="Adresa"
                            onChange={(e) => {
                                let { novaMusterija } = this.state;
                                novaMusterija.adresa = e.target.value;
                                this.setState({ novaMusterija });
                            }}/>
                    </Col>
                    <Col sm={{ size: 6, offset: 1 }}>
                        <Button className="mt-4" color="success" onClick={this.createNewMusterija.bind(this)}> Kreiraj </Button>
                    </Col>
                </Row>
            </div>
        );
    }
}