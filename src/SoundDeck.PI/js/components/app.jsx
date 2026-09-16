import React from "react";
import PlayAudioSettings from "./playAudioSettings";
import SamplerSettings from "./samplerSettings";

class App extends React.Component {
    render() {
        switch (this.props.uuid) {
            case "com.geekyeggo.sounddeck.playaudio":
                return <PlayAudioSettings />;

            case "com.geekyeggo.sounddeck.sampler":
                return <SamplerSettings />;

            default:
                return <div />;
        }
    }
}

export default App;
