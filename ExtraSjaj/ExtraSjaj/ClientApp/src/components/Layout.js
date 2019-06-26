import React, { Component } from 'react';
import { Container } from 'reactstrap';
import Drawer from '../Drawer';


export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
        <div>
            <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" />
            <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
            <Drawer props={this.props.children} />
      </div>
    );
  }
}
