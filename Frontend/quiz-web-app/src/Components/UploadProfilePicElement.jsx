import "../Styles/profilepage.css";

export default function UploadProfilePictureElement({setProfilePictureFile, setProfilePicture}) {
 
    const handleFileChange = async (e) => {
    
        const selectedFile = e.target.files[0];
        if (!selectedFile) {
            console.log('No file selected');
            return;
          }
        setProfilePictureFile(selectedFile);
        const reader = new FileReader();
        reader.onload = (event) => {
            const base64String = event.target.result.split(',')[1];
            console.log(base64String);
            setProfilePicture(base64String);
        };

        reader.readAsDataURL(selectedFile);
    };
   
    return (
        <div className="upload-picture-container">
            <input type="file" accept="image/*" onChange={handleFileChange}/>
        </div>
    );
}