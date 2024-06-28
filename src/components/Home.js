import React, { useState, useEffect } from 'react';
import Launcher from './Launcher'; // Ajuste o caminho conforme necessário
import '../css/Home.css';
import { useNavigate } from "react-router-dom";
import academy from '../helpers/stateCode';

const Home = ({ items }) => {
  const [isScreensaverActive, setScreensaverActive] = useState(false);
  const [academiaMaisProxima, setAcademiaMaisProxima] = useState(null)


  function GetLocation(){
    navigator.geolocation.getCurrentPosition(
      position => {
          let { latitude, longitude } = position.coords;
          let menorDistancia = Infinity;
          let academyNearby = null;

          academy.forEach(academia => {
            const rEarth = 6371;
            const dLat = (academia.latitude - latitude) * (Math.PI / 180);
            const dLon = (academia.longitude - longitude) * (Math.PI / 180);
            const a = Math.sin(dLat / 2) * Math.sin(dLat / 2) + Math.cos(latitude * (Math.PI / 180)) * Math.cos(academia.latitude * (Math.PI / 180)) * Math.sin(dLon / 2) * Math.sin(dLon / 2);          
            const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
            let distancia = rEarth * c; // Distância em km

            if (distancia < menorDistancia) {
              menorDistancia = distancia;
              academyNearby = academia;
            }
        });

          setAcademiaMaisProxima(academyNearby);
      },
      error => {
          console.error("Erro ao obter a localização", error);
      }
  );
  }

  useEffect(() => {
    let timeout;
    document.title = 'Allp Fit'
    GetLocation();

    const resetTimer = () => {
      clearTimeout(timeout);
      setScreensaverActive(false);
      timeout = setTimeout(() => setScreensaverActive(true), 720000); //720000 ms = 10 minutos
    };

    const handleUserActivity = () => resetTimer();

    window.addEventListener('mousemove', handleUserActivity);
    window.addEventListener('keypress', handleUserActivity);
    window.addEventListener('click', handleUserActivity);

    resetTimer(); // Inicializa o timer

    return () => {
      clearTimeout(timeout);
      window.removeEventListener('mousemove', handleUserActivity);
      window.removeEventListener('keypress', handleUserActivity);
      window.removeEventListener('click', handleUserActivity);
    };
  }, []);
  const navigate = useNavigate();
    const handleBack= () => {
        navigate('/planos');
    };


  return isScreensaverActive ? (
    <Launcher />
  ) : (
    <div className="home-page">
      <header className="header">
        <div className="header-container">
          <img fetchpriority="high" decoding="async" width="250" height="60" src="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp" alt="Allpfit Logo" />
        </div>
      </header>
      <div className="main">
        <div className='container'>
          {
            academiaMaisProxima ? (
              <div className="main-text">Seja bem-vindo (a) Unidade {academiaMaisProxima.nome} </div>
            ) : (
              <div className="main-text">Seja bem-vindo (a) AllpFit </div>
            )
          }
          
          <div className="sub-text">Escolha umas das opções abaixo para iniciar</div>
          <div className="items">
            {items && items.map((item, index) => (
              <div className="item" key={index} onClick={() => handleBack(item)}>
                <span>{item.text}</span>
                <div className="item-icon-container" >
                  <img src={item.icon} alt={item.text} className="item-icon" />
                </div>
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
}

export default Home;
