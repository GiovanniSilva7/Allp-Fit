import React, { useState } from 'react';
import academy from '../Helpers/stateCode';

// Helper para calcular a distância entre dois pontos (Localização do dispositivo e academia mais próxima)
function calculateDistance(lat1, lon1, lat2, lon2) {
  const rEarth = 6371; // Raio da Terra em Km
  const dLat = (lat2 - lat1) * (Math.PI / 180);
  const dLon = (lon2 - lon1) * (Math.PI / 180);
  const a =
    Math.sin(dLat / 2) * Math.sin(dLat / 2) +
    Math.cos(lat1 * (Math.PI / 180)) * Math.cos(lat2 * (Math.PI / 180)) *
    Math.sin(dLon / 2) * Math.sin(dLon / 2);
  const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
  return rEarth * c; // Distância em km
}

function LocalizeAcademy(latitude, longitude){

  const [academiaMaisProxima, setAcademiaMaisProxima] = useState(null);

  // Encontrar a academia mais próxima
  let menorDistancia = Infinity;
  let academyNearby = null;
  academy.forEach(academia => {
    const distancia = calculateDistance(latitude, longitude, academia.latitude, academia.longitude);
    if (distancia < menorDistancia) {
      menorDistancia = distancia;
      academyNearby = academia;
    }
  });

  setAcademiaMaisProxima(academyNearby);

  return academiaMaisProxima;

}

export default LocalizeAcademy;