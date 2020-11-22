import React from 'react';
import './Banner.css'

const Banner = ({ appName, token }) => {
  if (token) {
    return null;
  }
  return (
    <div className="banner my-banner">
      <div className="container">
        <h1 className="logo-font">
          {appName.toLowerCase()}
        </h1>
        <p>The best marketplace you've ever seen</p>
      </div>
    </div>
  );
};

export default Banner;
