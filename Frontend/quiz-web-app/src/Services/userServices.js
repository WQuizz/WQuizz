import jwtDecode from "jwt-decode";

export function logOut(cookies, setLoggedIn, navigate) {
    
    return () => {
        navigate("/");
      cookies.remove("jwt_authorization");
      console.log("logout");
      setLoggedIn(false);
    };
  }

  export async function fetchLoggedInUserProfile(token, setUser) {
    const decodedCookie = jwtDecode(token);
    const userName = decodedCookie["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
    const url = `http://localhost:9000/Profile/GetProfile?userName=${userName}`;
  
    try {
      const response = await fetch(url);
  
      if (response.ok) {
        const data = await response.json();
        // console.log(data);
        if (data?.userName) { 
          setUser(data);
        }
      } else {
        throw new Error(`Error: ${response.status} - ${response.statusText}`);
      }
    } catch (error) {
      console.error('Fetch Error:', error);
    }
  }

  export async function fetchUserProfile(userName, setUser) {
    const url = `http://localhost:9000/Profile/GetProfile?userName=${userName}`;
  
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
      throw error; // Re-throw the error to handle it in the component
    }
  }

  export async function uploadProfilePicture(userName, file) {
    try {
      const formData = new FormData();
      formData.append('userName', userName);
      formData.append('file', file);
  
      const response = await fetch('http://localhost:9000/Profile/UploadProfilePicture', {
        method: 'POST',
        body: formData,
      });
  
      if (response.ok) {
        console.log('Profile picture uploaded and user profile updated.');
      } else {
        console.error('Upload failed:', response.status, response.statusText);
      }
    } catch (error) {
      console.error('Error:', error);
    }
  }