import jwtDecode from "jwt-decode";
import { ProfileUrl } from "../Files/APIUrl";

export function logOut(cookies, setLoggedIn, navigate, setUserName) {
    
    return () => {
      cookies.remove("jwt_authorization");
      setLoggedIn(false);
      setUserName(null);
      navigate("/");
    };
  }

  export async function fetchLoggedInUserProfile(token, setUserName) {
    const decodedCookie = jwtDecode(token);
    const userName = decodedCookie["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
    const url = `${ProfileUrl}GetProfile?userName=${userName}`;
    try {
      const response = await fetch(url);
      if (response.ok) {
        const data = await response.json();
        if (data?.userName) { 
          setUserName(data.userName);
        }
      } else {
        throw new Error(`Error: ${response.status} - ${response.statusText}`);
      }
    } catch (error) {
      console.error('Fetch Error:', error);
    }
  }

  export async function fetchUserProfile(userName) {
    const url = `${ProfileUrl}GetProfile?userName=${userName}`;
  
    try {
      const response = await fetch(url);
  
      if (response.ok) {
        const data = await response.json();
        if (data?.userName) {
            
          return data;
        }
      } else {
        throw new Error(`Error: ${response.status} - ${response.statusText}`);
      }
    } catch (error) {
      console.error('Fetch Error:', error);
      throw error; 
    }
  }

  export async function updateProfile(userName, file, displayName) {
    try {
      const formData = new FormData();
      formData.append('userName', userName);
      formData.append('file', file);
      formData.append('displayName', displayName);
  
      const response = await fetch(`${ProfileUrl}UpdateProfile`, {
        method: 'POST',
        body: formData,
      });
  
     
    } catch (error) {
      console.error('Error:', error);
    }
  }

  export async function fetchUserProfilePicture(userName) {
    const url = `${ProfileUrl}GetProfilePicture?userName=${userName}`;
  
    try {
      const response = await fetch(url);
  
      if (response.ok) {
        const data = await response.json();
        if (data) {
          return data;
        }
      } else {
        throw new Error(`Error: ${response.status} - ${response.statusText}`);
      }
    } catch (error) {
      console.error('Fetch Error:', error);
      throw error;
    }
  }