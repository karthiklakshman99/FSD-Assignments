import React, { useState } from "react";
export default function ConditionRender2(props) {
    const [participantsLoggedIn, setlogInValue] = useState(!props.loggedIn);
    const names = props.namesList;

    const handleInput = () =>{
      setlogInValue(!participantsLoggedIn);
    }
    return (
      <div className="ConditionRender2">
        <h1>Welcome to StackRoute!!</h1>
        {participantsLoggedIn ?
        (
          <p><h4>Hello, {names !== undefined ? names[0] : "No Contact Details Found!!"}</h4></p>
        ) :
        (
          <p><h4>Please login to continue!!</h4></p>
        )
        }
        {participantsLoggedIn ? 
        (
          <button onClick={handleInput}>Display</button>
        ) :
        (
          <button onClick={handleInput}>Login Again</button>
        )
        }
      </div>
    );
  }
  