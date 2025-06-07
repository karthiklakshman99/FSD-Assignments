import './App.css';
import BodyComponent from './components/BodyComponent';
import FooterComponent from './components/FooterComponent';
import HeaderComponent from './components/HeaderComponent';

function App() {
  return (
    <div>
      <h1>learn react</h1>
      <HeaderComponent></HeaderComponent>
      <BodyComponent></BodyComponent>
      <FooterComponent></FooterComponent>
    </div>
  );
}

export default App;
