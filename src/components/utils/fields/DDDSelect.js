import React from 'react';
import { DDDs } from '../../../Helpers/dddHelper';

const DDDSelect = ({ selectedDDD, onChange }) => {
  return (
    <select className="ddi-select" value={selectedDDD} onChange={onChange}>
      <option value="" disabled>Selecione um DDD</option>
      {Object.entries(DDDs).map(([code, city]) => (
        <option key={code} value={code}>
          {code}
        </option>
      ))}
    </select>
  );
};

export default DDDSelect;
