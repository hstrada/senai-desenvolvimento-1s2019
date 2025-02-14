import React, { Component } from "react";
import {
  StyleSheet,
  View,
  Text,
  Image,
  ImageBackground,
  TextInput,
  TouchableOpacity,
  AsyncStorage
} from "react-native";
import api from "../services/api";

class SignIn extends Component {
  constructor(props) {
    super(props);
    this.state = { username: "", password: "" };
  }

  static navigationOptions = {
    header: null
  };

  _signInAsync = async () => {
    const resposta = await api.post("/login", {
      email: this.state.username,
      senha: this.state.password
    });

    const token = resposta.data.token;

    await AsyncStorage.setItem("userToken", token);
    this.props.navigation.navigate("App");
  };

  render() {
    return (
      <ImageBackground
        source={require("../assets/img/login.png")}
        style={StyleSheet.absoluteFillObject}
      >
        <View style={styles.overlay} />
        <View style={styles.container}>
          <Image
            source={require("../assets/img/loginIcon2x.png")}
            style={styles.imgLogin}
          />
          <TextInput
            style={styles.inputLogin}
            placeholder="username"
            placeholderTextColor="#FFFFFF"
            onChangeText={username => this.setState({ username })}
            underlineColorAndroid="#FFFFFF"
          />

          <TextInput
            style={styles.inputLogin}
            placeholder="password"
            placeholderTextColor="#FFFFFF"
            password="true"
            onChangeText={password => this.setState({ password })}
            underlineColorAndroid="#FFFFFF"
          />
          <TouchableOpacity style={styles.btnLogin} onPress={this._signInAsync}>
            <Text style={styles.btnLoginText}>LOGIN</Text>
          </TouchableOpacity>
        </View>
      </ImageBackground>
    );
  }
}

const styles = StyleSheet.create({
  overlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: "rgba(183, 39, 255, 0.79)"
  },
  container: {
    width: "100%",
    height: "100%",
    justifyContent: "center",
    alignContent: "center",
    alignItems: "center"
  },
  btnLogin: {
    height: 38,
    shadowColor: "rgba(0,0,0, 0.4)", // IOS
    shadowOffset: { height: 1, width: 1 }, // IOS
    shadowOpacity: 1, // IOS
    shadowRadius: 1, //IOS
    elevation: 3, // Android
    width: 240,
    borderRadius: 4,
    borderWidth: 1,
    borderColor: "#FFFFFF",
    backgroundColor: "#FFFFFF",
    justifyContent: "center",
    alignItems: "center",
    marginTop: 10
  },
  btnLoginText: {
    fontSize: 10,
    fontFamily: "OpenSans-Light",
    color: "#B727FF",
    letterSpacing: 4
  },
  inputLogin: {
    width: 240,
    marginBottom: 10,
    fontSize: 10
  },
  imgLogin: {
    tintColor: "#FFFFFF",
    height: 100,
    width: 90,
    margin: 10
  }
});

export default SignIn;
