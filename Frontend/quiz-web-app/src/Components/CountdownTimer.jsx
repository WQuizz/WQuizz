import React, { useState, useEffect } from 'react';
import "../Styles/countdowntimer.css";


function CountdownTimer(props) {
  const [time, setTime] = useState(30); // Initial time in seconds

  useEffect(() => {
    const timer = setInterval(() => {
      if (time > 0) {
        setTime((prevTime) => prevTime - 1);
      } else {
        clearInterval(timer);
      }
    }, 1000); // Update every second

    props.setTimeLimit(time);
    return () => clearInterval(timer);
  }, [time]);

  const progress = (time / 30) * 100; // Calculate progress percentage

  return (
    <div>
      
      <div className="progress">
        <div
          className={`progress-bar ${time === 0 ? 'animated' : ''}`}
          role="progressbar"
          style={{ width: `${progress}%`}}
          aria-valuenow={progress}
          aria-valuemin="0"
          aria-valuemax="100"
        >
          {time}
        </div>
      </div>
    </div>
  );
}

export default CountdownTimer;
