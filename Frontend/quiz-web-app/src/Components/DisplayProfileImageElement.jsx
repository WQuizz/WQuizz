import React, {useState, useEffect} from 'react';
import "../Styles/profilepage.css";

function DisplayProfileImageElement({profilePicture}) {
    const dataUrl = `data:image/jpeg;base64,${profilePicture}`;
    
    useEffect(()=>{},[profilePicture])

    const defaultImageUrl = 'https://upload.wikimedia.org/wikipedia/commons/1/1e/Default-avatar.jpg'; // Replace with your default image URL

    return (
        <div className='profile-picture-container'>
            {profilePicture ? (<img src={dataUrl} alt="Uploaded" className='profile-picture'/>) : (<img src={defaultImageUrl} alt="Default" className='profile-picture'/>)}
        </div>
    );
}

export default DisplayProfileImageElement;