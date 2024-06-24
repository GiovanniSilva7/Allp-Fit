import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import Launcher from '../src/components/Launcher';
import Home from '../src/components/Home';
import Plans from '../src/components/Plans';

import icon1 from "../src/img/icones-tela1.svg";
import icon2 from "../src/img/cadastro1.png";

function App() {
  const items = [
    {text:"LIBERAR CONVIDADO", icon:icon1 },
    {text:"CRIAR CADASTRO", icon:icon2 }
  ];
  const mainText = "Bem-vindo(a) à Allpfit!";
  const subText = "A única academia com conceito 'Top to All' do Brasil!";
  const iconTexts = [
    "Equipamentos de ponta",
    "Ambiente acolhedor",
    "Aulas presenciais e online",
    "Treine em casa com Allpfit"
  ];
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Navigate to="/home" />} />
        <Route path="/launcher" element={<Launcher mainText = {mainText} subText={subText} iconTexts={iconTexts}/>} />
        <Route 
          path="/home" 
          element={<Home items={items} />}  // Passando props usando renderização inline
        />
        <Route path="/planos" element={<Plans/>}/>

      </Routes>
    </Router>
  );
}

export default App;
