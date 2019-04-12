import React from "react";
import {
  ActivityIndicator,
  AsyncStorage,
  StatusBar,
  StyleSheet,
  View,
  Button,
  Text,
  Image,
  ImageBackground,
  TextInput,
  TouchableHighlight,
  TouchableOpacity
} from "react-native";

class SignIn extends React.Component {
  constructor(props) {
    super(props);
    this.state = { username: "", password: "" };
  }

  static navigationOptions = {
    // title: "Please sign in"
    header: null
  };

  state = {
    username: "",
    password: ""
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
            style={{
              tintColor: "#FFFFFF",
              height: 100,
              width: 90,
              margin: 10
            }}
          />
          <TextInput
            style={{ width: 240, marginTop: 10, fontSize: 10 }}
            placeholder="username"
            placeholderTextColor="#FFFFFF"
            onChangeText={username => this.setState({ username })}
            underlineColorAndroid="#FFFFFF"
          />

          <TextInput
            style={{ width: 240, marginBottom: 10, fontSize: 10 }}
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

  _signInAsync = async () => {
    console.warn(this.state.username + this.state.password);
    // await AsyncStorage.setItem("userToken", "abc");
    // this.props.navigation.navigate("App");
  };
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
  }
});

export default SignIn;
