import 'firebase/firestore';
import * as firebase from 'firebase';

const firebaseConfig = {
    apiKey: "AIzaSyBumvmeRH6O2n8wzLFN4Qhg3vAaivFAC6c",
    authDomain: "svigufo-b7214.firebaseapp.com",
    databaseURL: "https://svigufo-b7214.firebaseio.com",
    projectId: "svigufo-b7214",
    storageBucket: "svigufo-b7214.appspot.com",
    messagingSenderId: "960043967132",
    appId: "1:960043967132:web:23ad022829ae02c1"
  };

firebase.initializeApp(firebaseConfig);
// const firestore = firebase.firestore();
// firestore.settings({timestampsInSnapshots : true,});

export default firebase;