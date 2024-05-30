import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { ApiBaseUrl } from '../../../services/apiService';
import { DDDs } from '../../../Helpers/dddHelper';
import '../../../css/utils/Modals/PlanModal.css'

const PlanModal = ({ isOpen, onClose, onSelectPlan }) => {
  const [plans, setPlans] = useState(DDDs);
  const [selectedPlan, setSelectedPlan] = useState(null);

  useEffect(() => {
    if (isOpen) {
      axios.get(ApiBaseUrl + 'plans')
        .then(response => {
          setPlans(response.data);
        })
        .catch(error => {
          console.error('Error fetching plans', error);
        });
    }
  }, [isOpen]);

  const handleSelect = (plan) => {
    setSelectedPlan(plan);
    onSelectPlan(plan);
    onClose();
  };

  const handleSubmit = () => {
    onClose();
  };

  if (!isOpen) return null;

  return (
    <div className="modal">
    <div className="modal-content">
      <span className="close" onClick={onClose}>&times;</span>
      <h2>Selecione um plano.</h2>
      {plans.length === 0 ? (
        <p>Loading plans...</p>
      ) : (
        <form>
          {Object.entries(plans).map(([code, city], value) => (
            <div className='options-modal' key={code}>
              <label>
                <input
                className='input-radio'
                  type="radio"
                  name="plan"
                  value={code}
                  checked={selectedPlan === code}
                  onChange={handleSelect}
                />
                {code} - {city}
              </label>
            </div>
          ))}
          <button className='btn-selectPlan' type="button" onClick={handleSubmit}>Select</button>
        </form>
      )}
    </div>
  </div>
  );
};

export default PlanModal;
