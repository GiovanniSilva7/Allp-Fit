import React from 'react';
import '../css/Launcher.css';
import headerLogo from '../img/header_logo.svg';
import icon1 from '../img/sub-icones1.svg'
import icon2 from '../img/sub-icones2.svg'
import icon3 from '../img/sub-icones3.svg'
import icon4 from '../img/sub-icones4.svg'
<style>
@import url('https://fonts.googleapis.com/css2?family=Kanit:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap');
</style>


const Launcher = () => {
  return (
    <div className="home-page">
         <header className="header">
        <div className="header-container">
        <img fetchpriority="high" decoding="async" width="250" height="60" src={headerLogo}  alt="" data-lazy-srcset="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp 1024w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-300x74.png.webp 300w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-768x190.png.webp 768w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1.png.webp 1389w" data-lazy-sizes="(max-width: 800px) 100vw, 800px" data-lazy-src="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp" data-ll-status="loaded" sizes="(max-width: 800px) 100vw, 800px" srcset="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp 1024w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-300x74.png.webp 300w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-768x190.png.webp 768w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1.png.webp 1389w"/>
    </div>
    </header>
      <div className="main">
        <div className="main-text">seja bem-vindo (a)</div>
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
