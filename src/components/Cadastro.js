import React, { useState, useEffect } from "react";
import '../css/Cadastro.css';
import axios from 'axios';
import { setSelectionRange } from "@testing-library/user-event/dist/utils";
import { baseUrl } from "./UrlPath/ApiPath";

const Cadastro = () => {
    const [contractValue, setContractValue] = useState(null);
    const [anualValue, setanualValue] = useState(null);
    const [totalValue, settotalValue] = useState(null);
    const [ddds, setDdds] = useState([]);
    const [selectedDdd, setSelectedDdd] = useState('');
    const [country, setCountry] = useState([]);
    const [selectedCountry, setSelectedCountry] = useState('');

    useEffect(() => {
        const fetchData = async() => {
            try
            {
                const response = await axios.get(baseUrl + 'plans');
                const data = response.data;
                setContractValue(data.contractValue);
                setanualValue(data.anualValue);
                settotalValue(data.totalValue);
                setDdds(data.ddds);
                setCountry(data.country);
            }catch(error){
               console.error('Erro, api nao encontrada') 
            }

        };

        fetchData();
    }, []);

    const handleCountryChange = (event) =>{
        selectedCountry(event.target.value)
    }

    const handelDdsChange = (event) => {
        setSelectedDdd(event.target.value)
    }
  return (
    <div className="container">
      <header className="header">
        <div className="header-container">
        <img fetchpriority="high" decoding="async" width="250" height="60" src="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp" class="attachment-large size-large wp-image-3212 entered lazyloaded" alt="" data-lazy-srcset="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp 1024w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-300x74.png.webp 300w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-768x190.png.webp 768w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1.png.webp 1389w" data-lazy-sizes="(max-width: 800px) 100vw, 800px" data-lazy-src="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp" data-ll-status="loaded" sizes="(max-width: 800px) 100vw, 800px" srcset="https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-1024x253.png.webp 1024w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-300x74.png.webp 300w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1-768x190.png.webp 768w,  https://allpfit.com.br/wp-content/webp-express/webp-images/uploads/2023/06/logo-intro-1.png.webp 1389w"/>
    </div>
      </header>
      <div className="main-content">
        <div className="form-container">
          <h2 className="form-title">Cadastro</h2>
          <p className="form-subtitle">
            Já tem cadastro? <a href="Login.js" className="login-link">Clique aqui</a> para fazer o login.
          </p>
          <form className="form">
            <div className="form-group">
              <label className="form-label">Nome*</label>
              <input type="text" className="input-field"/>
            </div>
            <div className="form-group">
              <label className="form-label">Sobrenome*</label>
              <input type="text" className="input-field"/>
            </div>
            <div className="form-group">
              <label className="form-label">E-mail*</label>
              <input type="email" className="input-field"/>
            </div>
            <div className="form-group">
              <label className="form-label">CPF*</label>
              <input type="text" className="input-field"/>
            </div>
            <div className="form-group">
              <label className="form-label">Data de nascimento*</label>
              <input type="date" className="input-field"/>
            </div>
            <div className="form-group">
              <label className="form-label">Nacionalidade*</label>
              <select className="input-field" value={selectedCountry} onChange={handleCountryChange}>
                  {
                    country.length === 0 
                    ? (
                      <option>Carregando...</option>
                    ) 
                    : (country.map((country) => {
                      <option key={country} value={country}>{country}</option>
                    } 
                ))};
              </select>
            </div>
            <div className="form-group">
              <label className="form-label">DDI*</label>
              <div className="ddi-group">
                <select className="ddi-select" value={selectedDdd} onChange={handelDdsChange}  > 
                {
                  ddds.length === 0 
                  ? (
                      <option>Carregando</option>
                  ) 
                  : (
                      ddds.map((ddd) => {
                          <option key={ddd} value={ddd}> +{ddd}</option>
                      })
                  )
                };   
                </select>
                <input type="text" className="input-field"/>
              </div>
            </div>
            <div className="form-group gender-group">
              <label className="form-label">Gênero</label>
              <label className="gender-option">
                <input type="radio" name="gender" className="form-radio"/>
                <span>Masculino</span>
              </label>
              <label className="gender-option">
                <input type="radio" name="gender" className="form-radio"/>
                <span>Feminino</span>
              </label>
              <label className="gender-option">
                <input type="radio" name="gender" className="form-radio"/>
                <span>Outro</span>
              </label>
            </div>
          </form>
        </div>
        <div className="details-container">
          <h2 className="details-title">ALLP PLUS</h2>
          <div className="details-subtitle">
            Vigência: <span className="details-bold">recorrente mensal</span>
            <a href="#" className="details-link">Ver detalhes</a>
          </div>
          <div className="voucher-section">
            <label className="form-label">Código do voucher</label>
            <div className="voucher-group">
              <input type="text" className="input-field"/>
              <button className="apply-button">APLICAR</button>
            </div>
            <p className="voucher-note">
              Ao aplicar um voucher com desconto, o valor promocional do contrato será desconsiderado.
            </p>
          </div>
          <div className="price-box">
          <div className="price-row">
            <span>Contrato</span>
            <span className="new-price">{contractValue ? `R$${contractValue}` : 'Carregando...'}</span>
          </div>
          <div className="price-row">
            <span>Total</span>
            <span className="new-price">{totalValue ? `R$${totalValue}` : 'Carregando...'}</span>
          </div>
        </div>
        <div className="annual-box">
          <div className="price-row">
            <span>Anuidade (em 2x sem juros)</span>
            <span className="new-price">{anualValue ? `R$${anualValue}` : 'Carregando...'}</span>
          </div>
        </div>
          <div className="total-box">
            <span>Total (1ª cobrança)</span>
            <span className="total-price">{totalValue ? `R$${totalValue}` : 'Carregando...'}</span>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Cadastro;
