import React, { Component } from "react";
import { View, Text, Image, StyleSheet, AsyncStorage } from "react-native";

import jwt from "jwt-decode";

class Profile extends Component {
  static navigationOptions = {
    tabBarIcon: ({ tintColor }) => (
      <Image
        source={require("../assets/img/profile.png")}
        style={styles.imgProfile}
      />
    )
  };

  constructor(props) {
    super(props);
    this.state = { token: "", nome: "" };
  }

  _retrieveData = async () => {
    try {
      const value = await AsyncStorage.getItem("userToken");
      if (value !== null) {
        this.setState({ nome: jwt(value).Nome });
        this.setState({ token: value });
      }
    } catch (error) {}
  };

  componentDidMount() {
    this._retrieveData();
  }

  render() {
    return (
      <View style={styles.viewProfile}>
        <View style={styles.viewProfileHeader}>
          <View style={styles.viewProfileFlex}>
            <Image
              source={require("../assets/img/profile.png")}
              style={styles.viewProfileFlexHeader}
            />
            <Text style={styles.viewProfileFlexTitle}>
              {"Perfil".toUpperCase()}
            </Text>
          </View>
          <View style={styles.viewProfileLine} />
        </View>
        <View style={styles.container}>
          <View style={styles.containerProfile}>
            <Text>{this.state.token}</Text>
            <Text>{this.state.nome}</Text>
          </View>
        </View>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 4
  },
  containerProfile: {
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50,
    justifyContent: "center",
    alignItems: "center"
  },
  imgProfile: {
    width: 25,
    height: 25,
    tintColor: "#FFF"
  },
  viewProfile: {
    flex: 1,
    backgroundColor: "#F1F1F1"
  },
  viewProfileHeader: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center"
  },
  viewProfileFlex: {
    flexDirection: "row"
  },
  viewProfileFlexHeader: {
    width: 22,
    height: 22,
    tintColor: "#cccccc",
    marginRight: -9,
    marginTop: -9
  },
  viewProfileFlexTitle: {
    fontSize: 16,
    letterSpacing: 5,
    color: "#999999",
    fontFamily: "OpenSans-Regular"
  },
  viewProfileLine: {
    width: 170,
    paddingTop: 10,
    borderBottomColor: "gray",
    borderBottomWidth: 0.9
  }
});

export default Profile;
