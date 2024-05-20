import React, { useState, useEffect } from 'react';

function Planos() {
  const [planos, setPlanos] = useState([]);

  useEffect(() => {
    // Fetch planos data from backend
    fetch('/api/planos')
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
    </div>
  );
}

export default Planos;
