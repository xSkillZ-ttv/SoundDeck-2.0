import React from "react";
import PlayAudioSettings from "./playAudioSettings";
import SamplerSettings from "./samplerSettings";

class App extends React.Component {
    render() {
        switch (this.props.uuid) {
            case "com.skillz.sounddeck2.playaudio":
                return <PlayAudioSettings />;

            case "com.skillz.sounddeck2.sampler":
                return <SamplerSettings />;

            default:
                return <div />;
        }
    }
}

export default App;
