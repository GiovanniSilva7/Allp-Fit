import React, { useState, useEffect } from "react";
import '../css/Cadastro.css';
import axios from "axios";
import NationalitySelect from "./utils/fields/nacionalitySelect";
import { Nacionality } from "../Helpers/nacionalityHelper";
import DDDSelect from "./utils/fields/DDDSelect";
import { DDDs } from "../Helpers/dddHelper";
import PlanModal from "./utils/modals/PlanModal";

const Cadastro = () => {
    const [contractValue, setContractValue] = useState(null);
    const [anualValue, setanualValue] = useState(null);
    const [totalValue, settotalValue] = useState(null);

    // useEffect(() => {
    //     const fetchData = async() => {
    //         try
    //         {
    //             const response = await axios.get(baseUrl + 'plans');
    //             const data = response.data;
    //             setContractValue(data.contractValue);
    //             setanualValue(data.anualValue);
    //             settotalValue(data.totalValue);
    //             setDdds(data.ddds);
    //             setCountry(data.country);
    //         }catch(error){
    //            console.error('Erro, api nao encontrada') 
    //         }

    //     };

    //     fetchData();
    // }, []); Não faz tanto sentido ter isso, pois tem coisas que é melhor serem tratadas no front-end

    
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [cpf, setCpf] = useState('');
    const [birthDate, setBirthDate] = useState('');
    const [nacionality, setNacionality] = useState(Nacionality.brasileiro);
    const [phoneNumber, setPhoneNumber] = useState('');
    const [selectedDdds, setDdds] = useState(DDDs[11]);

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedPlan, setSelectedPlan] = useState(null);

    useEffect(() => {}, [])

    const handleChangeNacionality = (event) => {
        setNacionality(event.target.value)
    }

    const handelDdsChange = (event) => {
        setDdds(event.target.value)
    }

    const handleOpenModal = () => {
      setIsModalOpen(true);
    };
  
    const handleCloseModal = () => {
      setIsModalOpen(false);
    };
  
    const handleSelectPlan = (plan) => {
      setSelectedPlan(plan);
    };

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
          Já tem cadastro? <a href="Login" className="login-link">Clique aqui</a> para fazer o login.
          </p>
          <form className="form">
            <div className="form-group">
              <label className="form-label">Nome*</label>
              <input type="text" onChange={(e) => setName(e.target.value)} className="input-field"/>
            </div>
            <div className="form-group">
              <label className="form-label">Sobrenome*</label>
              <input type="text" onChange={(e) => setSurname(e.target.value)} className="input-field"/>
            </div>
            <div className="form-group">
              <label className="form-label">E-mail*</label>
              <input type="email" onChange={(e) => setEmail(e.target.value)} className="input-field"/>
            </div>
            <div className="form-group">
              <label className="form-label">CPF*</label>
              <input type="text" onChange={(e) => setCpf(e.target.value)} className="input-field"/>
            </div>
            <div className="form-group">
              <label className="form-label">Data de nascimento*</label>
              <input type="date" onChange={(e) => setBirthDate(e.target.value)} className="input-field"/>
            </div>
            <div className="form-group">
              <label className="form-label">Nacionalidade*</label>
              <NationalitySelect selectedNationality={nacionality} onChange={handleChangeNacionality} />
            </div>
            <div className="form-group">
              <label className="form-label">DDI*</label>
              <div className="ddi-group">
                <DDDSelect selectedDDD={selectedDdds} onChange={handelDdsChange} />
                <input type="text" className="input-field"/>
              </div>
            </div>
          </form>
        </div>
        <div className="details-container">
          <h2 className="details-title">ALLP PLUS</h2>
          <div className="details-subtitle">
         {selectedPlan && (
            <p>
              Plano Selectionado: {selectedPlan.name} - ${selectedPlan.price}
            </p>
          )}
          <PlanModal
            isOpen={isModalOpen}
            onClose={handleCloseModal}
            onSelectPlan={handleSelectPlan}
          />
            <a href="#" onClick={handleOpenModal} className="details-link">Ver detalhes</a>
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
