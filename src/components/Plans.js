import React from 'react';
import { useNavigate } from 'react-router-dom';
import '../css/Plans.css'; // Importe o arquivo CSS

const Plans = () => {
  const navigate = useNavigate();

  const handleBackClick = () => {
    navigate('/home');
  };

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
          <span>VOLTAR</span>
        </button>
        </div>
        
      </header>
      <div className="main">
      <div className="iframe-container">
      <iframe className="iframe-main" loading="lazy" width="1000" height="940" src="https://evo-totem.w12app.com.br/allpfit/13/site/Hv4bY2JnGwWmsXXwsihPng%5BEQUAL%5D%5BEQUAL%5D" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen="" data-rocket-lazyload="fitvidscompatible" data-lazy-src="https://evo-totem.w12app.com.br/allpfit/13/site/Hv4bY2JnGwWmsXXwsihPng%5BEQUAL%5D%5BEQUAL%5D" data-ll-status="loaded" class="entered lazyloaded"></iframe>
            </div>
            </div>
    </div>
  );
}

export default Plans;
