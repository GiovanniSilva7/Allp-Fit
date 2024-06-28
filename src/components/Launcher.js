import React,{useState, useEffect } from 'react';
import '../css/Launcher.css';
import headerLogo from '../img/header_logo.svg';
import icon1 from '../img/sub-icones1.svg'
import icon2 from '../img/sub-icones2.svg'
import icon3 from '../img/sub-icones3.svg'
import icon4 from '../img/sub-icones4.svg'
import academy from '../helpers/stateCode';

const Launcher = () => {

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

  useEffect(() => { GetLocation()}, []);

  return (
    <div className="home-page">
         <header className="header">
        <div className="header-container">
        <img fetchpriority="high" decoding="async" width="250" height="60" src={headerLogo}  alt="" data-lazy-srcset="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp 1024w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-300x74.png.webp 300w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-768x190.png.webp 768w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1.png.webp 1389w" data-lazy-sizes="(max-width: 800px) 100vw, 800px" data-lazy-src="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp" data-ll-status="loaded" sizes="(max-width: 800px) 100vw, 800px" srcset="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp 1024w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-300x74.png.webp 300w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-768x190.png.webp 768w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1.png.webp 1389w"/>
    </div>
    </header>
      <div className="main">
          {
            academiaMaisProxima ? (
              <div className="main-text">Seja bem-vindo (a) Unidade {academiaMaisProxima.nome} </div>
            ) : (
              <div className="main-text">Seja bem-vindo (a) AllpFit </div>
            )
          }
        <div className="sub-text">A ÚNICA ACADEMIA COM CONCEITO TOP <b>TO ALL</b> DO BRASIL!</div>
        <div className="icons">
          <div className="icon">
            <img src={icon1}/>
            <p>Aparelhos de última geração</p>
          </div>
          <div className="icon">
            <img src={icon2} />
            <p>Ambiente familiar</p>
          </div>
          <div className="icon">
            <img src={icon3}/>
            <p>Aulas na academia ou em casa</p>
          </div>
          <div className="icon">
            <img src={icon4} />
            <p>Allpfit home</p>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Launcher;
