import {
  createStackNavigator,
  createAppContainer,
  createBottomTabNavigator,
  createSwitchNavigator
} from "react-navigation";

import Main from "./pages/main";
import Profile from "./pages/profile";
import SignIn from "./pages/signin";

const AuthStack = createStackNavigator({ SignIn });



const MainNavigator = createBottomTabNavigator(
  {
    Main,
    Profile
  },
  {
    swipeEnabled: true,
    tabBarOptions: {
      showLabel: false,
      showIcon: true,
      inactiveBackgroundColor: "#B727FF",
      activeBackgroundColor: "#B727FF",
      activeTintColor: "#FFFFFF",
      inactiveTintColor: "#FFFFFF",
      style: {
        height: 50
      }
    }
  }
);

// export default createAppContainer(MainNavigator);

export default createAppContainer(
  createSwitchNavigator(
    {
      MainNavigator,
      AuthStack
    },
    { initialRouteName: "AuthStack" }
  )
);
