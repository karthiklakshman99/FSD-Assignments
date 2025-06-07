import React, { Component } from 'react'
import ClassComponent from './ClassComponent'

export default class ParentClassComponent extends Component {
    name = "Karthik";
  render() {
    return (
      <>
        <ClassComponent name = {this.name}/>
        <ClassComponent />
      </>
    )
  }
}
