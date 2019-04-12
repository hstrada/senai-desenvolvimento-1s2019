import React, { Component } from "react";
import { View, Button, Text, Image, StyleSheet } from "react-native";

class Profile extends Component {
  static navigationOptions = {
    // tabBarLabel: "Home",
    tabBarIcon: ({ tintColor }) => (
      <Image
        source={require("../assets/img/profile.png")}
        style={{ width: 25, height: 25, tintColor: "#FFF" }}
      />
    )
  };

  render() {
    return (
      <View style={{ flex: 1, backgroundColor: "#F1F1F1" }}>
        <View
          style={{
            flex: 1,
            // backgroundColor: "powderblue",
            justifyContent: "center",
            alignItems: "center"
          }}
        >
          <View style={{ flexDirection: "row" }}>
            {/* <View> */}
            <Image
              source={require("../assets/img/profile.png")}
              style={{
                width: 22,
                height: 22,
                tintColor: "#cccccc",
                marginRight: -9,
                marginTop: -9
              }}
            />
            {/* </View> */}
            <Text
              style={{
                fontSize: 16,
                letterSpacing: 5,
                color: "#999999",
                fontFamily: "OpenSans-Regular"
              }}
            >
              {"Perfil".toUpperCase()}
            </Text>
          </View>
          <View
            style={{
              width: 170,
              paddingTop: 10,
              borderBottomColor: "gray",
              borderBottomWidth: 0.9
            }}
          />
        </View>
        <View style={styles.container} />
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    // backgroundColor: "#fafafa",
    flex: 4
  }
});

export default Profile;
