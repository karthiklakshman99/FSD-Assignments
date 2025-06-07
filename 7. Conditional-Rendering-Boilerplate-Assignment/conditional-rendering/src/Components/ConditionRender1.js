import React from "react";

export default function ConditionRender1(props) {
    const names = props.namesList;
    const firstName = names !== undefined ? names[0] : "";
    return (
      <>
      <div className="ConditionRender1">
        <div>
          {(!names || names.length === 0) ? (
            <p>No Contact Details Found!!</p>
          ) :
          (
            names.map((name, index) => (
              <p key={index}>{name}</p>
            ))
          )} 
        </div>
        <div>
          {firstName ? (
            <p>First Person:{firstName}</p>
          ) : null}
        </div>
      </div>
      </>
    );
  }
  
  