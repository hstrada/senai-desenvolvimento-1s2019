import { createBottomTabNavigator, createAppContainer, createStackNavigator, createSwitchNavigator } from "react-navigation";
import "./config/StatusBarConfig";

import Main from "./pages/main";
import Profile from "./pages/profile";
import SignInScreen from "./pages/signin";

const AuthStack = createStackNavigator({ SignIn: SignInScreen });

const TabNavigator = createBottomTabNavigator(
  {
    Main,
    Profile
  },
  {
    // headerMode: "none",
    swipeEnabled: true,
    tabBarOptions: {
      showLabel: false,
      showIcon: true,
      inactiveBackgroundColor: "#B727FF",
      // activeBackgroundColor: "#9900e6",
      activeBackgroundColor: "#B727FF",
      activeTintColor: "#FFFFFF",
      inactiveTintColor: "#FFFFFF",
      style: {
        height: 50
        // ,width: 50
      }
      // ,labelStyle: {
      //   padding: 5
      // }
    }
  }
);

export default createAppContainer(
  createSwitchNavigator(
    {
      App: TabNavigator,
      Auth: AuthStack
    },
    {
      initialRouteName: "Auth"
    }
  )
);

// export default { TabNavigator };
