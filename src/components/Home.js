import React, { useState, useEffect } from 'react';
import Launcher from './Launcher'; // Ajuste o caminho conforme necessário
import '../css/Home.css';
import icon1 from "../img/icones-tela1.svg";
import icon2 from "../img/cadastro1.png";
import redirectLocation from '../components/utils/fields/redirectLocation'
import { useNavigate } from "react-router-dom";

const Home = ({ items }) => {
  const [isScreensaverActive, setScreensaverActive] = useState(false);

  useEffect(() => {
    let timeout;

    const resetTimer = () => {
      clearTimeout(timeout);
      setScreensaverActive(false);
      timeout = setTimeout(() => setScreensaverActive(true), 10000000000000);
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
  /*const handleLocation = (icon) => {
    

    if(icon === icon2){
      redirectLocation();
    }else if (icon === icon1){
      
    }
  };*/

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
        <div className="main-text">Seja bem-vindo (a)</div>
        <div className="sub-text">Escolha umas das opções abaixo para iniciar</div>
        <div className="items">
          {items && items.map((item, index) => (
            <div className="item" key={index} onClick={() => handleBack(item.icon)}>
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
