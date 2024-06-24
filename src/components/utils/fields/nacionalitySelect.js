import React from 'react';
import { Nacionality } from '../../../Helpers/nacionalityHelper';

const NationalitySelect = ({ selectedNationality, onChange }) => {
  return (
    <select className="input-field" value={selectedNationality} onChange={onChange}>
      {Object.entries(Nacionality).map(([key, value]) => (
        <option key={key} value={value}>
          {value}
        </option>
      ))}
    </select>
  );
};

export default NationalitySelect;
