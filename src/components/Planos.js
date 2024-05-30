import axios from 'axios';
import React, { useState, useEffect } from 'react';

function Planos() {
  const [planos, setPlanos] = useState([]);

  useEffect(() => {
    // Fetch planos data from backend
    axios.get('plan')
      .then(response => response.json())
      .then(data => setPlanos(data));
  }, []);

  return (
    <div>
      {planos.map(plano => (
        <div key={plano.id}>
          <h2>{plano.nome}</h2>
          <p>{plano.descricao}</p>
          <button>Selecionar</button>
        </div>
      ))}
      <h2>Planos</h2>
    </div>
  );
}

export default Planos;
