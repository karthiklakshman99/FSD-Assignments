import React,{useState} from 'react'

export default function FunctionalComponent(props) {
    const [flagValue, setFlagValue] = useState(false);
    const name = props.name;
    const ChangeFlagValue = () => {
        setFlagValue(!flagValue);
    }
  return (
    <>
      <div>
        <h1>
            Functional Component : Hello, {name}!!
            {flagValue ? <h2>Welcome to React, {name}!!</h2> : <h2></h2>}
            <div>
                <button onClick={ChangeFlagValue}>Click me to get Welcome message</button>
            </div>
        </h1>
      </div>
    </>
  )
}
