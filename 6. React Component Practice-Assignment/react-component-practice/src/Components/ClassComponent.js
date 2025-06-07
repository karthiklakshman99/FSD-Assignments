import React, { Component } from 'react'

export default class ClassComponent extends Component {
  render() {
    return (
      <>
        <div>
            {this.props.name ?
                <h1>
                    Class Component : Goodbye, All the best for your future endeavours !! {this.props.name}!!
                </h1> :
                <h1>
                    Class Component : Goodbye, All the best for your future endeavours !! Guest!!
                </h1>
            }
        </div>
      </>
    )
  }
}
