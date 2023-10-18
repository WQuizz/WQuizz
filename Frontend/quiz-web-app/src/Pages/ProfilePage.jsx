import ProfileElement from "../Components/ProfileElement";
import { useParams } from 'react-router-dom';
import { useEffect, useState } from "react";
import { fetchUserProfile } from "../Services/userServices";
import "../Styles/profilepage.css";

export default function ProfilePage({ user }) {
    const { userName } = useParams();
    const [userProfile, setUserProfile] = useState(null);
    const [isYourProfile, setIsYourProfile] = useState(false);

    useEffect(() => {
        // You can access the userName from the URL here
        async function getUserProfile() {
            setIsYourProfile(userName === user?.userName);
            if (isYourProfile) {
                setUserProfile(user);
            } else {
                try {
                    const newUser = await fetchUserProfile(userName);
                    setUserProfile(newUser);
                } catch (error) {
                    console.error('Error fetching user profile:', error);
                }
            }
        }

        getUserProfile();
    }, [userName, user]);

    useEffect(() => { }, [user, userProfile]);

    return (
        <div className="profilepage">
            {userProfile?.userName && <ProfileElement user={userProfile} canEdit={isYourProfile}/>}
            {!userProfile && <div style={{ position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)', color:"white" }}>User Doesn't exist :3</div>}
        </div>
    )
}