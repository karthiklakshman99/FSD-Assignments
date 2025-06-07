import './App.css';
import ConditionRender1 from './Components/ConditionRender1';
import ConditionRender2 from './Components/ConditionRender2';

function App() {
  const nameList = undefined;
  const participantsLoggedIn = true;
  const namesArray = ["Alpha", "Beta", "Gama", "Delta"];
  return (
    <div className='App'>
      <h1>Condition Rendering</h1>
      <ConditionRender1 names={nameList}></ConditionRender1>
      <ConditionRender2 loggedIn={participantsLoggedIn}></ConditionRender2>
      <h1>Condition Rendering Again!!</h1>
      <ConditionRender1 namesList={namesArray}></ConditionRender1>
      <ConditionRender2 loggedIn={participantsLoggedIn} namesList = {namesArray}></ConditionRender2>
    </div>
  );
}

export default App;
