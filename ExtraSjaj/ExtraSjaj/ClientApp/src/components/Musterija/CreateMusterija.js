import React, { Component } from 'react';
import { Button, Table, InputGroup, InputGroupAddon, InputGroupText, Input, Label, Row, Col } from 'reactstrap';
import axios from 'axios';


export class CreateMusterija extends Component {

    static renderMusterijasTable() {
        return (
            <Row>
                <Col sm={{ size: 6, offset: 1 }}>
                    <Label className="mr-2" for="ime"> Ime </Label>
                    <Input className="mr-2" type="text" id="Ime" placeholder="Ime" />
                </Col>
                <Col  sm={{ size: 6, offset: 1 }}>
                    <Label className="mr-2" for="prezime"> Prezime </Label>
                    <Input className="mr-2" type="text" id="Ime" placeholder="Prezime" />
                </Col>
                <Col sm={{ size: 6, offset: 1 }}>
                    <Label className="mr-2" for="prezime"> Broj telefona </Label>
                    <Input className="mr-2" type="text" id="Ime" placeholder="Broj telefona" />
                </Col>
                <Col sm={{ size: 6, offset: 1 }}>
                    <Label className="mr-2" for="prezime"> Adresa </Label>
                    <Input className="mr-2" type="text" id="Ime" placeholder="Adresa" />
                </Col>
                <Col sm={{ size: 6, offset: 1 }}>
                    <Button className="mt-4" color="success"> Kreiraj </Button>
                </Col>
            </Row>
        );
    }

    render() {
        
        let contents = CreateMusterija.renderMusterijasTable();

        return (
            <div>
                <h1>Lista mušterija</h1>
                {contents}
            </div>
        );
    }


}