import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import Cadastro from '../src/components/Cadastro';
import Planos from '../src/components/Planos';
import Checkout from '../src/components/Checkout';
import DoLogin from '../src/components/Login';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Navigate to="/cadastro" />} />
        <Route path="/cadastro" element={<Cadastro />} />
        <Route path="/planos" element={<Planos />} />
        <Route path="/checkout" element={<Checkout />} />
        <Route path="/login" element={<DoLogin />} />
      </Routes>
    </Router>
  );
}

export default App;
