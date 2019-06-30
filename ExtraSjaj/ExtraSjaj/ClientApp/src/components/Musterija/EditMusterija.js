import React, { Component } from 'react';
import { Button, Input, Label, Row, Col } from 'reactstrap';
import axios from 'axios';
import { browserHistory } from 'react-router';

export class EditMusterija extends Component {


    constructor(props) {

        super(props)

    }

    state = {

        novaMusterija: {
            id: this.props.location.state.Edit.id,
            ime: this.props.location.state.Edit.ime,
            prezime: this.props.location.state.Edit.prezime,
            brojTelefona: this.props.location.state.Edit.brojTelefona,
            adresa: this.props.location.state.Edit.adresa
        }

    }
   
    editMusterija() {

        axios.put("api/Musterijas/" + this.state.novaMusterija.id, this.state.novaMusterija);
        browserHistory.push('/Musterije');

    }

    render() {
        return (
            <div>
                <h1>Izmena mušterija</h1>
                <Row>
                    <Col sm={{ size: 6, offset: 1 }}>
                        <Label className="mr-2" for="ime"> Ime </Label>
                        <Input className="mr-2" id="ime" placeholder="Ime"
                            value={this.state.novaMusterija.ime}
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
                            value={this.state.novaMusterija.prezime}
                            onChange={(e) => {
                                let { novaMusterija } = this.state;
                                novaMusterija.prezime = e.target.value;
                                this.setState({ novaMusterija });
                            }} />
                    </Col>
                    <Col sm={{ size: 6, offset: 1 }}>
                        <Label className="mr-2" for="prezime"> Broj telefona </Label>
                        <Input className="mr-2" type="text" id="brojTelefona" placeholder="Broj telefona"
                            value={this.state.novaMusterija.brojTelefona}
                            onChange={(e) => {
                                let { novaMusterija } = this.state;
                                novaMusterija.brojTelefona = e.target.value;
                                this.setState({ novaMusterija });
                            }} />
                    </Col>
                    <Col sm={{ size: 6, offset: 1 }}>
                        <Label className="mr-2" for="prezime"> Adresa </Label>
                        <Input className="mr-2" type="text" id="adresa" placeholder="Adresa"
                            value={this.state.novaMusterija.adresa}
                            onChange={(e) => {
                                let { novaMusterija } = this.state;
                                novaMusterija.adresa = e.target.value;
                                this.setState({ novaMusterija });
                            }} />
                    </Col>
                    <Col sm={{ size: 6, offset: 1 }}>
                        <Button className="mt-4" color="success" onClick={this.editMusterija.bind(this)}> Izmeni </Button>
                    </Col>
                </Row>
            </div>
        );
    }


}