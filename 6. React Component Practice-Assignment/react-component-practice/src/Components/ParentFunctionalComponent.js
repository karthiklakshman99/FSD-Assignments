import React from 'react'
import FunctionalComponent from './FunctionalComponent'

export default function ParentFunctionalComponent() {
    const name = "Karthik";
  return (
    <>
      <FunctionalComponent name = {name}/>
    </>
  )
}
