import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import '../css/Plans.css'; // Importe o arquivo CSS
import academy from '../helpers/stateCode';


const Plans = () => {
  const navigate = useNavigate();

  const handleBackClick = () => {
    navigate('/home');
  };

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
    document.title = 'Planos'
    GetLocation()
  }, []);

  return (
    <div className="plans-page">
      <header className="header-plan">
        <div className="header-container-plan">
          <img
            fetchpriority="high"
            decoding="async"
            width="250"
            height="60"
            src="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp"
            alt="Allpfit Logo"
            sizes="(max-width: 800px) 100vw, 800px"
            srcSet="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp 1024w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-300x74.png.webp 300w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-768x190.png.webp 768w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1.png.webp 1389w"
          />
          <button className="back-button" onClick={handleBackClick}>
            <span>ENCERRAR PROCESSO</span>
          </button>
        </div>
        
      </header>
      <div className="main">
        <div className="iframe-container">
          { academiaMaisProxima ? (
            <iframe className="iframe-main" loading="lazy" width="1500" height="935" src={academiaMaisProxima.iframe} allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen  data-rocket-lazyload="fitvidscompatible" data-lazy-src={academiaMaisProxima.iframe} data-ll-status="loaded" class="entered lazyloaded"></iframe>
          ) : (
            <h3>Carregando mais informações dos planos...</h3>
          )}
        </div>
      </div>
    </div>
  );
}

export default Plans;
