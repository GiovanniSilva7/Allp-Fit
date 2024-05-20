import {React, useState, useEffect} from "react";
import axios from "axios";
import '../css/Checkout.css';

const Checkout = () => {
  const [contractValue, setContractValue] = useState(null);
    const [anualValue, setanualValue] = useState(null);
    const [totalValue, settotalValue] = useState(null);

    useEffect(() => {
        const fetchData = async() => {
            try
            {
                const response = await axios.get('API');
                const data = response.data;
                setContractValue(data.contractValue);
                setanualValue(data.anualValue);
                settotalValue(data.totalValue);
            }catch(error){
               console.error('Erro, api nao encontrada') 
            }

        };
        fetchData();
    }, []);
  return (
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
            <span className="total-price">R$9,90</span>
          </div>
        </div>
  );
};

export default Checkout;
