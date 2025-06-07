import React from 'react';
import Adapter from 'enzyme-adapter-react-16';
import { shallow, configure } from 'enzyme';
import LifeCycleMount from '../Components/LifeCycleMount';

configure({adapter: new Adapter()});

test('LifeCycle renders UnMounted after DidUnmount Lifecycle', () => {
    const LifeCycleWrapper = shallow(<LifeCycleMount />)
    
    setTimeout(() => {
        expect(LifeCycleWrapper.state('name')).toEqual('UnMounted')
    }, 9000)
});