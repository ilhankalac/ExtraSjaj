import React, { Component } from 'react';
import { Container } from 'reactstrap';
import Drawer from '../Drawer';


export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
        <div>
            <Drawer props={this.props.children} />
      </div>
    );
  }
}
