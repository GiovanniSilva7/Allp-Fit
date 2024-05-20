import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import Cadastro from '../src/components/Cadastro';
import Planos from '../src/components/Planos';
import Checkout from '../src/components/Checkout';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Navigate to="/cadastro" />} />
        <Route path="/cadastro" element={<Cadastro />} />
        <Route path="/planos" element={<Planos />} />
        <Route path="/checkout" element={<Checkout />} />
        
      </Routes>
    </Router>
  );
}

export default App;
