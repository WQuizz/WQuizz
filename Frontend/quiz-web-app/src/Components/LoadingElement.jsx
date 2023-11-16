import React from 'react';
import { css } from '@emotion/react';
import { RingLoader } from 'react-spinners';
import "../Styles/loading.css";

const override = css`
  display: block;
  margin: 0 auto;
  border-color: red;
`;

const LoadingElement = () => {
  return (
    <div className="loading-spinner">
      <RingLoader css={override} size={150} color={'#36D7B7'} loading={true} />
    </div>
  );
};

export default LoadingElement;